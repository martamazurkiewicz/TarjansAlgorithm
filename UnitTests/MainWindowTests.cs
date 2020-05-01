using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Project;
using System.Windows.Controls;
using System.Threading;

namespace UnitTests
{
    [TestFixture]
    class MainWindowTests
    {
        [Test]
        public void CheckInputAndAddNeighboursTest()
        {
            var window = new MainWindow
            {
                neighborsTextBoxes = new List<TextBox>() {
                    new TextBox
                    {
                        Text = "1,3,8"
                    },
                    new TextBox
                    {
                        Text = "1,7,2"
                    },
                    new TextBox
                    {
                        Text = "4,4,8"
                    } },
                graph = new Graph(3)
            };
            Assert.Throws<System.ArgumentOutOfRangeException>(() => window.CheckInputAndAddNeighbours());
        }
    }
}
