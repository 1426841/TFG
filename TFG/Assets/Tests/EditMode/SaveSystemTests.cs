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
            SaveSystem saveSystem = new SaveSystem();
            File.Delete(Application.dataPath + SaveSystem.SaveFilePath);
            Assert.IsFalse(File.Exists(Application.dataPath + SaveSystem.SaveFilePath));
            
            saveSystem.Save("0:0,0");
            Assert.IsTrue(File.Exists(Application.dataPath + SaveSystem.SaveFilePath));
        }
    }
}
