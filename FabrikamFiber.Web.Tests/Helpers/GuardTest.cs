using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FabrikamFiber.Web.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FabrikamFiber.Web.Helpers;
    using NUnit.Framework;

    [TestFixture]
    public class GuardTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ItShouldThrowExceptionIfArgumentIsNull()
        {
            Web.Helpers.Guard.ThrowIfNull(null, "value");
        }

        [Test]
        public void ItShouldNotThrowExceptionIfArgumentIsNotNull()
        {
            Web.Helpers.Guard.ThrowIfNull("this is not null", "value");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ItShouldThrowExceptionIfArgumentIsNullOrEmpty()
        {
            Web.Helpers.Guard.ThrowIfNullOrEmpty(string.Empty, "value");
        }

        [Test]
        public void ItShouldNotThrowExceptionIfArgumentIsNotNullOrEmpty()
        {
            Web.Helpers.Guard.ThrowIfNullOrEmpty("not null or empty", "value");
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ItShouldThrowExceptionIfArgumentIsLesserThanZero()
        {
            Web.Helpers.Guard.ThrowIfLesserThanZero(-1, "value");
        }

        [Test]
        public void ItShouldNotThrowExceptionIfArgumentIsNotLesserThanZero()
        {
            Web.Helpers.Guard.ThrowIfLesserThanZero(1, "value");
        }
    }
}
