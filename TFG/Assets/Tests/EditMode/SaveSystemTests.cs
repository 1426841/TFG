using System.IO;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class SaveSystemTests
    {
        [Test]
        public void Save()
        {
            File.Delete(Application.dataPath + "/SaveFile.json");
            Assert.IsFalse(File.Exists(Application.dataPath + "/SaveFile.json"));
            SaveSystem saveSystem = new SaveSystem();
            saveSystem.Save("0:0,0");
            Assert.IsTrue(File.Exists(Application.dataPath + "/SaveFile.json"));
        }
    }
}
