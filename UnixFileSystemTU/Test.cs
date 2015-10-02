//
//  Test.cs
//
//  Author:
//       Bastien Balaud <bastien.balaud@gmail.com>
//
//  Copyright (c) 2015 Bastien Balaud
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
//  Test.cs
//
//  Author:
//       hurrycane <>
//
//  Copyright (c) 2015 hurrycane
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystem;


namespace TUFileSytem
{
	[TestFixture ()]
	public class Test
	{
		public Directory racine= new Directory ();
		[TearDownAttribute] public void Init()
		{
			racine.content.Clear ();
			racine.chmod (6);
		}
		[Test ()]
		public void mkdir ()
		{

			Assert.AreEqual(racine.mkdir("Test"),true);
			Assert.AreEqual (racine.content.Count (), 1);
		}
		[Test ()]
		public void mkdirConflitNom ()
		{
			Assert.AreEqual(racine.mkdir("Test"),true);
			Assert.AreEqual(racine.mkdir("Test"),false);
		}
		[Test ()]
		public void mkdirPermissionDefault ()
		{
			racine.mkdir ("JAVAPOWA");
			Directory JAVAPOWA =(Directory) racine.cd ("JAVAPOWA");
			Assert.AreEqual (JAVAPOWA.permission , 6);
		}
		[Test ()]
		public void cdReturnSameName ()
		{
			racine.mkdir ("test");
			Assert.AreEqual (racine.cd("test").name, "test");

		}
		[Test ()]
		public void cdIncorectName()
		{
			//La fonction doit retourner un null
			Assert.AreEqual (racine.cd("test"), null);
		}
		[Test ()]
		public void lsReturnContent ()
		{
			File JAVA = new File ("JAVA", racine);
			racine.content.Add (JAVA);
			Assert.AreEqual (racine.ls (), racine.content);
		}
		[Test ()]
		public void parentGoodName ()
		{
			racine.mkdir ("OPENJDK");
			Directory OPENJDK =(Directory) racine.cd ("OPENJDK");
			Assert.AreEqual (OPENJDK.parent, racine);
		}
		[Test ()]
		public void parentBadName ()
		{
			Assert.AreEqual (racine.parent, null);
		}
		[Test ()]
		public void create ()
		{

			Assert.AreEqual(racine.createNewFile("Test"),true);
			Assert.AreEqual (racine.content.Count (), 1);
		}
		[Test ()]
		public void createConflitNom ()
		{
			Assert.AreEqual(racine.createNewFile("Test"),true);
			Assert.AreEqual(racine.createNewFile("Test"),false);
		}
		[Test ()]
		public void getPathRoot()
		{
			Assert.AreEqual (racine.getPath(), "/");
		}
		[Test ()]
		public void getPath()
		{
			racine.mkdir ("JAVA");
			Directory JAVA =(Directory) racine.cd ("JAVA");
			Assert.AreEqual(JAVA.getPath(),"/JAVA/");

		}
		[Test ()]
		public void chmodCorrect7()
		{
			racine.chmod (7);
			Assert.AreEqual (racine.permission, 7);
			Assert.AreEqual (racine.canExecute (), true);
			Assert.AreEqual (racine.canWrite (), true);
			Assert.AreEqual(racine.canRead(),true);
		}
		[Test ()]
		public void chmodCorrect6()
		{
			racine.chmod (6);
			Assert.AreEqual (racine.permission, 6);
			Assert.AreEqual (racine.canExecute (), false);
			Assert.AreEqual (racine.canWrite (), true);
			Assert.AreEqual(racine.canRead(),true);
		}
		[Test ()]
		public void chmodCorrect5()
		{
			racine.chmod (5);
			Assert.AreEqual (racine.permission, 5);
			Assert.AreEqual (racine.canExecute (), true);
			Assert.AreEqual (racine.canWrite (),false );
			Assert.AreEqual(racine.canRead(),true);
		}
		[Test ()]
		public void chmodCorrect4()
		{
			racine.chmod (4);
			Assert.AreEqual (racine.permission, 4);
			Assert.AreEqual (racine.canExecute (), false);
			Assert.AreEqual (racine.canWrite (),false );
			Assert.AreEqual(racine.canRead(),true);
		}
		[Test ()]
		public void chmodCorrect3()
		{
			racine.chmod (3);
			Assert.AreEqual (racine.permission, 3);
			Assert.AreEqual (racine.canExecute (), true);
			Assert.AreEqual (racine.canWrite (),true );
			Assert.AreEqual(racine.canRead(),false);
		}
		[Test ()]
		public void chmodCorrect2()
		{
			racine.chmod (2);
			Assert.AreEqual (racine.permission, 2);
			Assert.AreEqual (racine.canExecute (), false);
			Assert.AreEqual (racine.canWrite (),true );
			Assert.AreEqual(racine.canRead(),false);
		}
		[Test ()]
		public void chmodCorrect1()
		{
			racine.chmod (1);
			Assert.AreEqual (racine.permission, 1);
			Assert.AreEqual (racine.canExecute (), true);
			Assert.AreEqual (racine.canWrite (),false);
			Assert.AreEqual(racine.canRead(),false);
		}
		[Test ()]
		public void chmodCorrect0()
		{
			racine.chmod (0);
			Assert.AreEqual (racine.permission, 0);
			Assert.AreEqual (racine.canExecute (), false);
			Assert.AreEqual (racine.canWrite (),false);
			Assert.AreEqual(racine.canRead(),false);
		}
		[Test ()]
		public void chmodIncorrect()
		{
			racine.chmod (8);
			Assert.AreEqual (racine.permission, 6);
		}
	}
}

