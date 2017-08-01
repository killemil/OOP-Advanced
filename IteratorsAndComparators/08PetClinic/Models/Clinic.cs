namespace _08PetClinic.Models
{
    using System;
    using _08PetClinic.Interfaces;
    using System.Collections.Generic;
    using System.Text;

    public class Clinic
    {
        private string name;
        private int roomsNumber;
        private RoomsRegister roomsRegister;
        private int occupiedRooms;

        public Clinic(string name, int roomsNumber)
        {
            this.Name = name;
            this.RoomsNumber = roomsNumber;
            this.roomsRegister = new RoomsRegister(roomsNumber);
            this.occupiedRooms = 0;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public int RoomsNumber
        {
            get
            {
                return this.roomsNumber;
            }
            private set
            {
                if (value % 2 == 0)
                {
                    throw new ArgumentException("Invalid Operation!");
                }

                this.roomsNumber = value;
            }
        }

        public bool TryAddPet(Pet pet)
        {
            foreach (var roomIndex in this.roomsRegister)
            {
                if (this.roomsRegister[roomIndex] == null)
                {
                    this.roomsRegister[roomIndex] = pet;
                    this.occupiedRooms++;
                    return true;
                }
            }

            return false;
        }

        public bool TryReleasePet()
        {
            int centralRoomIndex = this.RoomsNumber / 2;
            for (int i = 0; i < this.RoomsNumber; i++)
            {
                int currentIndex = (centralRoomIndex + i) % this.RoomsNumber;
                if (this.roomsRegister[currentIndex] != null)
                {
                    this.roomsRegister[currentIndex] = null;
                    this.occupiedRooms--;
                    return true;
                }
            }

            return false;
        }

        public string Print(int roomIndex)
        {
            return this.roomsRegister[roomIndex]?.ToString() ?? "Room empty";
        }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.RoomsNumber; i++)
            {
                sb.AppendLine(this.Print(i));
            }

            return sb.ToString().Trim();
        }

        public bool HasEmptyRooms()
        {
            return this.occupiedRooms < this.RoomsNumber;
        }
    }
}
