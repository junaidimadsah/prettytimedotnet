using PrettyTime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace PrettyTime.NET_Tests
{
    
    
    /// <summary>
    ///This is a test class for PrettyTimeTest and is intended
    ///to contain all PrettyTimeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PrettyTimeTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for "right now"
        ///</summary>
        [TestMethod()]
        public void RightNow()
        {
            using (PrettyTime p = new PrettyTime())
            {
                Assert.AreEqual("right now", p.format(DateTime.Now));
            }
        }

        /// <summary>
        ///A test for minutes from now
        ///</summary>
        [TestMethod()]
        public void MinutesFromNow()
        {
            using (PrettyTime p = new PrettyTime())
            {
                Assert.AreEqual("12 minutes from now", p.format(DateTime.Now.AddMinutes(12)));
            }
        }

        /// <summary>
        ///A test for minutes from now
        ///</summary>
        [TestMethod()]
        public void CustomFormat()
        {
            using (PrettyTime p = new PrettyTime())
            {
                p.setUnits(new units.Custom()
                {
                    Format = new BasicTimeFormat().setPattern("%n %u").setRoundingTolerance(20).setFutureSuffix("... RUN!")
                        .setFuturePrefix("self destruct in: ").setPastPrefix("self destruct was: ")
                        .setPastSuffix(" ago..."),
                    MaxQuantity = 0,
                    MillisPerUnit = 5000,
                    Name = "tick",
                    PluralName = "ticks"
                });

                Assert.AreEqual("self destruct in: 5 ticks... RUN!", p.format(DateTime.Now.AddMilliseconds(25000)));
                p.reference = DateTime.Now.AddMilliseconds(25000);
                Assert.AreEqual("self destruct was: 5 ticks ago...", p.format(DateTime.Now));
            }
        }

        /// <summary>
        ///A test for hours from now
        ///</summary>
        [TestMethod()]
        public void HoursFromNow()
        {
            using (PrettyTime p = new PrettyTime())
            {
                Assert.AreEqual("3 hours from now", p.format(DateTime.Now.AddHours(3)));
            }
        }

        /// <summary>
        ///A test for days from now
        ///</summary>
        [TestMethod()]
        public void DaysFromNow()
        {
            using (PrettyTime p = new PrettyTime())
            {
                Assert.AreEqual("3 days from now", p.format(DateTime.Now.AddDays(3)));
            }
        }

        /// <summary>
        ///A test for weeks from now
        ///</summary>
        [TestMethod()]
        public void WeeksFromNow()
        {
            using (PrettyTime p = new PrettyTime())
            {
                Assert.AreEqual("3 weeks from now", p.format(DateTime.Now.AddDays(21)));
            }
        }

        /// <summary>
        ///A test for months from now
        ///</summary>
        [TestMethod()]
        public void MonthsFromNow()
        {
            using (PrettyTime p = new PrettyTime())
            {
                Assert.AreEqual("3 months from now", p.format(DateTime.Now.AddMonths(3)));
            }
        }

        /// <summary>
        ///A test for years from now
        ///</summary>
        [TestMethod()]
        public void YearsFromNow()
        {
            using (PrettyTime p = new PrettyTime())
            {
                Assert.AreEqual("3 years from now", p.format(DateTime.Now.AddYears(3)));
            }
        }

        /// <summary>
        ///A test for decades from now
        ///</summary>
        [TestMethod()]
        public void DecadesFromNow()
        {
            using (PrettyTime p = new PrettyTime())
            {
                Assert.AreEqual("30 years from now", p.format(DateTime.Now.AddYears(30).AddDays(7)));
            }
        }

        /// <summary>
        ///A test for centuries from now
        ///</summary>
        [TestMethod()]
        public void CenturiesFromNow()
        {
            using (PrettyTime p = new PrettyTime())
            {
                Assert.AreEqual("300 years from now", p.format(DateTime.Now.AddYears(300).AddDays(7)));
            }
        }

        /// <summary>
        ///A test for moments ago
        ///</summary>
        [TestMethod()]
        public void MomentsAgo()
        {
            using (PrettyTime p = new PrettyTime())
            {
                Assert.AreEqual("moments ago", p.format(DateTime.Now.AddMilliseconds(-6000)));
            }
        }

        /// <summary>
        ///A test for minutes ago
        ///</summary>
        [TestMethod()]
        public void MinutesAgo()
        {
            using (PrettyTime p = new PrettyTime())
            {
                Assert.AreEqual("12 minutes ago", p.format(DateTime.Now.AddMinutes(-12)));
            }
        }

        /// <summary>
        ///A test for hours ago
        ///</summary>
        [TestMethod()]
        public void HoursAgo()
        {
            using (PrettyTime p = new PrettyTime())
            {
                Assert.AreEqual("3 hours ago", p.format(DateTime.Now.AddHours(-3)));
            }
        }

        /// <summary>
        ///A test for days ago
        ///</summary>
        [TestMethod()]
        public void DaysAgo()
        {
            using (PrettyTime p = new PrettyTime())
            {
                Assert.AreEqual("3 days ago", p.format(DateTime.Now.AddDays(-3)));
            }
        }

        /// <summary>
        ///A test for weeks ago
        ///</summary>
        [TestMethod()]
        public void WeeksAgo()
        {
            using (PrettyTime p = new PrettyTime())
            {
                Assert.AreEqual("3 weeks ago", p.format(DateTime.Now.AddDays(-21)));
            }
        }

        /// <summary>
        ///A test for months ago
        ///</summary>
        [TestMethod()]
        public void MonthsAgo()
        {
            using (PrettyTime p = new PrettyTime())
            {
                Assert.AreEqual("3 months ago", p.format(DateTime.Now.AddMonths(-3)));
            }
        }

        /// <summary>
        ///A test for years ago
        ///</summary>
        [TestMethod()]
        public void YearsAgo()
        {
            using (PrettyTime p = new PrettyTime())
            {
                Assert.AreEqual("3 years ago", p.format(DateTime.Now.AddYears(-3)));
            }
        }

        /// <summary>
        ///A test for decades ago
        ///</summary>
        [TestMethod()]
        public void DecadesAgo()
        {
            using (PrettyTime p = new PrettyTime())
            {
                Assert.AreEqual("30 years ago", p.format(DateTime.Now.AddYears(-30)));
            }
        }

        /// <summary>
        ///A test for centuries ago
        ///</summary>
        [TestMethod()]
        public void CenturiesAgo()
        {
            using (PrettyTime p = new PrettyTime())
            {
                Assert.AreEqual("300 years ago", p.format(DateTime.Now.AddYears(-300)));
            }
        }
    }
}