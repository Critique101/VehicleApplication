using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_xl
{
    class Vehicle
    {
        private string licenseplate;
        private int modelyear;

        public Vehicle() { }

        public Vehicle(string licenseplate, int modelyear)
        {
            this.licenseplate = licenseplate;
            this.modelyear = modelyear;
        }

        public string Registernummer
        {
            get { return this.licenseplate; }
            set { this.licenseplate = value; }
        }

        public int Yearmoddel
        {
            get { return this.modelyear; }
            set { this.modelyear = value; }
        }
    }

    class Car : Vehicle
    {
        private string carBrand;

        public Car(string licenseplate, int modelyear, string carBrand) : base(licenseplate, modelyear)
        {
            this.CarBrand = carBrand;
        }

        public string CarBrand
        {
            get { return this.carBrand; }
            set { this.carBrand = value; }
        }
    }
    class Mc : Vehicle
    {
        private string mcType;

        public Mc(string licenseplate, int modelyear, string mcType) : base(licenseplate, modelyear)
        {
            this.McType = mcType;
        }

        public string McType
        {
            get { return this.mcType; }
            set { this.mcType = value; }
        }

    }
    class Truck : Vehicle
    {
        private int truckWeight;

        public Truck(string licenseplate, int modelyear, int truckWeight) : base(licenseplate, modelyear)
        {
            this.TruckWeight = truckWeight;
        }

        public int TruckWeight
        {
            get { return this.truckWeight; }
            set { this.truckWeight = value; }
        }
    }
}