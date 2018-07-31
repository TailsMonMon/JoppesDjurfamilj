﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoppesDjurfamilj {
    class Cat : Animal {
        public Cat(int _age, string _name, string _favFood, string _breed) : base(_age, _name, _favFood, _breed) {
            this.age = _age;
            this.name = _name;
            this.favFood = _favFood;
            this.breed = _breed;
        }

        public override void Interact(Ball ball) {
            Console.WriteLine("Cat play with ball");
        }

        public override void HungryAnimal() {
            throw new NotImplementedException();
        }
    }
}
