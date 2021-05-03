using NUnit.Framework;
using PersonalFinances.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonalFinances.Tests
{
    public class PersonalFinances_IsRealeaseShould
    {
        private PersonalFinance _personalFinance;

        [SetUp]
        public void Setup()
        {
            _personalFinance = new PersonalFinance();
        }

        [Test]
        public void ShouldReleaseOneCreditRelease()
        {
            var newRelease = new Release() { Account = "Itau", Date = DateTime.Now, Description = "Salario Best Soft", Type = "c", Value = 10000.00m};
            _personalFinance.AddRelease(newRelease);

            Assert.IsFalse(_personalFinance.ReleaseAmount != 1, "Lista de lançamentos deve conter 1 lançamento!");
            Assert.IsFalse(_personalFinance.ReleaseItems[0].Type != "c", "Lista de lançamentos deve conter 1 lançamento de Crédito!");
            Assert.IsFalse(_personalFinance.ReleaseItems[0].Value != 10000.00m, "Valor do lançamento não confere com o valor lançado!");
        }

        [Test]
        public void ShouldReleaseOneDebitRelease()
        {
            var newRelease = new Release() { Account = "Itau", Date = DateTime.Now, Description = "Tarifa da Conta", Type = "d", Value = 50.00m };
            _personalFinance.AddRelease(newRelease);

            Assert.IsFalse(_personalFinance.ReleaseAmount != 1, "Lista de lançamentos deve conter 1 lançamento!");
            Assert.IsFalse(_personalFinance.ReleaseItems[0].Type != "d", "Lista de lançamentos deve conter 1 lançamento de Débito!");
            Assert.IsFalse(_personalFinance.ReleaseItems[0].Value != 50.00m, "Valor do lançamento não confere com o valor lançado!");
        }
    }
}
