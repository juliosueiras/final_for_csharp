using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GroupProject
{
    class SkillRecord
    {
        public static int RECORD_SIZE = 203;
        private int _skillID;
        private string _skillName;
        private string _skillLevel;
        private int _yearsExperience;
        private string _desc;

        public SkillRecord()
        {
            SkillID = 1;
            SkillName = "";
            SkillLevel = "";
            YearsExperience = 0;
            Desc = "";
        }

        public SkillRecord(int skillID, string skillName, string skillLevel, int yearsExperience, string desc)
        {
            SkillID = skillID;
            SkillName = skillName;
            SkillLevel = skillLevel;
            YearsExperience = yearsExperience;
            Desc = desc;
        }

        public void write(FileStream file)
        {
            BinaryWriter bw = new BinaryWriter(file);  //hover over BinaryWriter -> how to read the namespace in intellisense?           
            //write data in field order
            bw.Write(SkillID);
            formatName(bw, SkillName);
            formatName(bw, SkillLevel);
            bw.Write(YearsExperience);
            formatDesc(bw, Desc);
        }

        private void formatDesc(BinaryWriter bw, string n)
        {
            StringBuilder sb = new StringBuilder(n);
            sb.Length = 128;
            bw.Write(sb.ToString()); //this is where the 1B prefix is added
        }

        private void formatName(BinaryWriter bw, string n)
        {
            StringBuilder sb = new StringBuilder(n);
            sb.Length = 32;
            bw.Write(sb.ToString()); //this is where the 1B prefix is added
        }

        public void read(FileStream raFile)
        {
            BinaryReader br = new BinaryReader(raFile);
            SkillID = br.ReadInt32();
            SkillName = br.ReadString().Replace('\0',' ');
            SkillLevel = br.ReadString().Replace('\0', ' ');
            YearsExperience = br.ReadInt32();
            Desc = br.ReadString().Replace('\0', ' ');            
        }

        public int SkillID
        {
            get { return _skillID; }
            set { _skillID = value; }
        }

        public string SkillName
        {
            get { return _skillName; }
            set { _skillName = value; }
        }

        public string SkillLevel
        {
            get { return _skillLevel; }
            set { _skillLevel = value; }
        }

        public int YearsExperience
        {
            get { return _yearsExperience; }
            set { _yearsExperience = value; }
        }

        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }
    }
}
