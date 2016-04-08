using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SkillTracker
{
    class SkillRecord
    {
        public static int RECORD_SIZE = 204;

        private int _skillID;
        private string _skillName;
        private string _skillLevel;
        private int _yearsExperience;
        private string _desc;

        public SkillRecord()
        {
            SkillID = 0;
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

        public void Write(FileStream file)
        {
            BinaryWriter bw = new BinaryWriter(file);           
            //write data in field order
            bw.Write(SkillID);
            bw.Write(FormatString(SkillName, 32));
            bw.Write(FormatString(SkillLevel, 32));
            bw.Write(YearsExperience);
            bw.Write(FormatString(Desc, 128));
        }

        private string FormatString(string n, int maxStringLength)
        {
            StringBuilder sb = new StringBuilder(n);
            sb.Length = maxStringLength;
            return sb.ToString();
        }

        public void Read(FileStream file)
        {
            BinaryReader br = new BinaryReader(file);
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
