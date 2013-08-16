﻿using System;
using System.Linq;
using System.Reflection;
using Fixie;
using Fixie.Conventions;

namespace FixieDemo.Example8_Categories
{
    public class CustomConvention : Convention
    {
        public CustomConvention(RunContext runContext)
        {
            var desiredCategories = runContext.Options["include"].ToArray();
            var shouldRunAll = !desiredCategories.Any();

            Classes
                .Where(type => type.IsInNamespace(GetType().Namespace))
                .NameEndsWith("Tests");

            Cases
                .Where(method => method.Void())
                .Where(method => shouldRunAll || MethodHasAnyDesiredCategory(method, desiredCategories));

            if (!shouldRunAll)
            {
                Console.WriteLine("Categories: " + string.Join(", ", desiredCategories));
                Console.WriteLine();
            }
        }

        static bool MethodHasAnyDesiredCategory(MethodInfo method, string[] desiredCategories)
        {
            return Categories(method).Any(testCategory => desiredCategories.Contains(testCategory.Name));
        }

        static CategoryAttribute[] Categories(MethodInfo method)
        {
            return method.GetCustomAttributes<CategoryAttribute>(true).ToArray();
        }
    }
}