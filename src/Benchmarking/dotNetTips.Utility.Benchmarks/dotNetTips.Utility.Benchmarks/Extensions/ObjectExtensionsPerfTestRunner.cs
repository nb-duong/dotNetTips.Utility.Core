﻿// ***********************************************************************
// Assembly         : dotNetTips.Utility.Benchmarks
// Author           : David McCarter
// Created          : 10-04-2019
//
// Last Modified By : David McCarter
// Last Modified On : 12-05-2019
// ***********************************************************************
// <copyright file="ObjectExtensionsPerfTestRunner.cs" company="dotNetTips.Utility.Benchmarks">
//     Copyright (c) McCarter Consulting. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BenchmarkDotNet.Attributes;
using dotNetTips.Utility.Standard.Extensions;
using dotNetTips.Utility.Standard.Tester;
using dotNetTips.Utility.Standard.Tester.Models;

namespace dotNetTips.Utility.Benchmarks.Extensions
{
    [BenchmarkCategory(nameof(ObjectExtensions))]
    public class ObjectExtensionsPerfTestRunner : PerfTestRunner
    {
        private string _peopleJson;

        private PersonProper _person;

        public override void Setup()
        {
            base.Setup();

            this._person = RandomData.GeneratePerson<PersonProper>();
            this._peopleJson = this._person.ToJson();
        }

        [Benchmark(Description = nameof(ObjectExtensions.As))]
        public void TestAs()
        {
            var result = this._person.As<IPerson>();

            base.Consumer.Consume(result);
        }

        [Benchmark(Description = nameof(ObjectExtensions.Clone))]
        public void TestClone()
        {
            var result = this._person.Clone<PersonProper>();

            base.Consumer.Consume(result);
        }

        [Benchmark(Description = nameof(ObjectExtensions.ComputeMD5Hash))]
        public void TestComputeMD5Hash()
        {
            var result = this._person.ComputeMD5Hash();

            base.Consumer.Consume(result);
        }

        [Benchmark(Description = nameof(ObjectExtensions.ComputeSha256Hash))]
        public void TestComputeSha256Hash()
        {
            var result = this._person.ComputeSha256Hash();

            base.Consumer.Consume(result);
        }

        [Benchmark(Description = nameof(ObjectExtensions.DisposeFields))]
        public void TestDisposeFields()
        {
            System.Data.DataTable disposableType = new System.Data.DataTable("TEST");

            disposableType.DisposeFields();
        }

        [Benchmark(Description = nameof(ObjectExtensions.FromJson))]
        public void TestFromJson()
        {
            var result = this._peopleJson.FromJson<PersonProper>();

            base.Consumer.Consume(result);
        }

        [Benchmark(Description = nameof(ObjectExtensions.HasProperty))]
        public void TestHasProperty()
        {
            var result = this._person.HasProperty("City");

            base.Consumer.Consume(result);
        }

        [Benchmark(Description = nameof(ObjectExtensions.IsNotNull))]
        public void TestIsNotNull()
        {
            var result = this._person.IsNotNull();

            base.Consumer.Consume(result);
        }

        [Benchmark(Description = nameof(ObjectExtensions.IsNull))]
        public void TestIsNull()
        {
            var result = this._person.IsNull();

            base.Consumer.Consume(result);
        }

        [Benchmark(Description = nameof(ObjectExtensions.StripNull))]
        public void TestStripNull()
        {
            var result = this._person.StripNull();

            base.Consumer.Consume(result);
        }

        [Benchmark(Description = nameof(ObjectExtensions.ToJson))]
        public void TestToJson()
        {
            var result = this._person.ToJson();

            base.Consumer.Consume(result);
        }

        [Benchmark(Description = nameof(ObjectExtensions.TryDispose))]
        public void TestTryDispose()
        {
            System.Data.DataTable disposableType = new System.Data.DataTable("TEST");

            disposableType.TryDispose();
        }
    }
}
