﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Greedy.Architecture.Drawing;
using Greedy.Tests;
using NUnit.Framework;

namespace Greedy.Architecture
{
    public class BasePerformanceTests
    {
        protected static void AssertWonWithTimout(int timeLimit, StateTestCase stateTestCase, IPathFinder pathFinderToTest)
        {
            var controller = RunWithTimeout(
                () => TestsHelper.LoadStateFromInputData_And_MoveThroughPath(stateTestCase.InputData, pathFinderToTest, stateTestCase.Name),
                timeLimit,
                $"Your solution exceeded timeout on test {stateTestCase.Name}. Time limit is {timeLimit} ms");
            Assert.IsTrue(controller.GameIsWon, controller.GameLostMessage);
        }

        protected static T RunWithTimeout<T>(Func<T> func, int timeout, string message)
        {
            var task = Task.Run(func);
            if (!task.Wait(timeout))
            {
                Assert.Fail(message);
            }
            return task.Result;
        }
    }
}