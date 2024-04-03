using NUnit.Framework;
using MyLibrary;

namespace MyLibrary.Tests
{
    public class MyClassTests
    {
        [Test]
        public void MyList_ShouldContainValues()
        {
            MyClass myClass = new MyClass();
            myClass.MyList.Add(1);
            myClass.MyList.Add(2);
            myClass.MyList.Add(3);

            Assert.AreEqual(3, myClass.MyList.Count);
        }
    }
}
