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
            
            saveSystem.Save("0:0,0",0);
            Assert.IsTrue(File.Exists(Application.dataPath + SaveSystem.SaveFilePath));
            File.Delete(Application.dataPath + SaveSystem.SaveFilePath);
        }

        [Test]
        public void Load()
        {
            SaveSystem saveSystem = new SaveSystem();
            File.Delete(Application.dataPath + SaveSystem.SaveFilePath);


            saveSystem.Save("0:10,0", 10);
            SaveSystem.SaveFile saveFile = new SaveSystem.SaveFile();
            saveFile = saveSystem.Load();
            Assert.AreEqual(saveFile.time, "0:10,0");
            Assert.AreEqual(saveFile.totalTime, 10);

            saveSystem.Save("0:11,0", 11);
            saveFile = saveSystem.Load();
            Assert.AreEqual(saveFile.time, "0:10,0");
            Assert.AreEqual(saveFile.totalTime, 10);

            saveSystem.Save("0:9,0", 9);
            saveFile = saveSystem.Load();
            Assert.AreEqual(saveFile.time, "0:9,0");
            Assert.AreEqual(saveFile.totalTime, 9);

            File.Delete(Application.dataPath + SaveSystem.SaveFilePath);
        }
    }
}
