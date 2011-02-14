using Dap;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for FormMainTest and is intended
    ///to contain all FormMainTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FormMainTest
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
        ///A test for Train
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Dap.exe")]
        public void TrainTest()
        {
            FormMain_Accessor target = new FormMain_Accessor();
            target.sqareSideLengthA = 3;
            target.sqareSideLengthB = 3;

            target.AllocateNetwork(3, 3);

            target.rawSamples.Add(null);
            target.rawSamples.Add(null);
            target.rawSamples.Add(null);

            target.xCookedSamples = new double[3][];
            target.xCookedSamples[0] = new double[] { 1, -1, -1 };
            target.xCookedSamples[1] = new double[] { -1, 1, -1 };
            target.xCookedSamples[2] = new double[] { -1, -1, 1 };

            target.yCookedSamples = new double[3][];
            target.yCookedSamples[0] = new double[] { -1, -1, 1 };
            target.yCookedSamples[1] = new double[] { -1, 1, -1 };
            target.yCookedSamples[2] = new double[] { 1, -1, -1 };

            double[,] expected = new double[,] { { -1, -1, 3 }, { -1, 3, -1 }, { 3, -1, -1 } };

            target.Train();

            for (int i = 0; i < 3; i++) for (int j = 0; j < 3; j++)
                    Assert.AreEqual(expected[i, j], target.w[i, j], 1e-1);
        }

        /// <summary>
        ///A test for FeedForward
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Dap.exe")]
        public void FeedForwardTest()
        {
            FormMain_Accessor target = new FormMain_Accessor();
            target.sqareSideLengthA = 3;
            target.sqareSideLengthB = 3;

            target.AllocateNetwork(3, 3);

            target.rawSamples.Add(null);
            target.rawSamples.Add(null);
            target.rawSamples.Add(null);

            target.xCookedSamples = new double[3][];
            target.xCookedSamples[0] = new double[] { 1, -1, -1 };
            target.xCookedSamples[1] = new double[] { -1, 1, -1 };
            target.xCookedSamples[2] = new double[] { -1, -1, 1 };

            target.yCookedSamples = new double[3][];
            target.yCookedSamples[0] = new double[] { -1, -1, 1 };
            target.yCookedSamples[1] = new double[] { -1, 1, -1 };
            target.yCookedSamples[2] = new double[] { 1, -1, -1 };

            target.Train();

            double[] actual = target.FeedForward(new double[] { 1, -1, -1 });

            double[] expected = new double[] { -3, -3, 5 };

            for (int i = 0; i < 3; i++)
                Assert.AreEqual(expected[i], actual[i], 1e-1);

            expected = new double[] { -1, -1, 1 };

            target.BinarizeToPlusMinus(ref actual);

            for (int i = 0; i < 3; i++)
                Assert.AreEqual(expected[i], actual[i], 1e-1);
        }

        /// <summary>
        ///A test for RecognizeAtoB
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Dap.exe")]
        public void RecognizeAtoBTest()
        {
            FormMain_Accessor target = new FormMain_Accessor(); // TODO: Initialize to an appropriate value
            target.sqareSideLengthA = 3;
            target.sqareSideLengthB = 3;
            target.w = new double[,] { { -1, -1, 3 }, { -1, 3, -1 }, { 3, -1, -1 } };
            double[] task = new double[] { 1, -1, -1};
            double[] expected = new double[] { -1, -1, 1 };
            double[] actual;

            actual = target.RecognizeAtoB(task);

            for (int i = 0; i < 3; i++)
                Assert.AreEqual(expected[i], actual[i], 1e-1);
        }
    }
}
