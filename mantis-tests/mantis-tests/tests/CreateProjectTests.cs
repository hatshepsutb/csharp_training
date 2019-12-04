using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace mantis_tests
{
    [TestFixture]
    public class CreateProjectTests : TestBase
    {

        [Test]
        public void CreateProjectTest() 
        {
            AccountData account = new AccountData("administrator", "root");
            //List<ProjectData> oldList = ProjectData.GetAll();

            List <mantis.ProjectData> mantisProjectData = app.API.GetProjectsList(account);

            List<ProjectData> oldList = mantisProjectData.Select(e => new ProjectData(e.name, e.description)).ToList();


            ProjectData project = new ProjectData("New Project8");
            project.Description = "New Description8";

            app.Project.Create(project);



            List<mantis.ProjectData>  newMantisProjectData = app.API.GetProjectsList(account);
            List<ProjectData> newList = newMantisProjectData.Select(e => new ProjectData(e.name, e.description)).ToList();

            oldList.Add(project);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
