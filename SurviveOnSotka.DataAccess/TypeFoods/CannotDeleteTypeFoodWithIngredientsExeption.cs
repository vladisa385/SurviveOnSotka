﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SurviveOnSotka.DataAccess.TypeFoods
{
    public class CannotDeleteTypeFoodWithIngredientsExeption : Exception

    {
        public CannotDeleteTypeFoodWithIngredientsExeption()
               : base("TypeFood cannot be deleted, if there are ingredient in it.") { }
    }
}