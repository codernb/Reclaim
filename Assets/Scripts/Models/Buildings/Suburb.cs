using System;

namespace Assets.Scripts.Models.Buildings
{
    [Serializable]
    class Suburb : Building
    {

        private string name;
        private float integrity = 1;

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public float getIntegrity()
        {
            return integrity;
        }

        public void setIntegrity(float integrity)
        {
            this.integrity = integrity;
        }
    }
}
