﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetHotel.Models;
using DAL;

namespace PetHotel.Controllers
{
    public class InvoiceController : Controller
    {
        private ViewModelContext Db = new ViewModelContext();

        // GET: /Invoice/
        public ActionResult Index()
        {
            var invoices = Db.Invoices.Include(i => i.Customer).Include(o=>o.OrderItems);
            return View(invoices.ToList());
        }

        // GET: /Invoice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = Db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: /Invoice/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(Db.Customers, "CustomerID", "FirstName");
            return View();
        }

        // POST: /Invoice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="InvoiceId,OrderDate,CustomerID,Totalprice")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                Db.Invoices.Add(invoice);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(Db.Customers, "CustomerID", "FirstName", invoice.CustomerID);
            return View(invoice);
        }

        // GET: /Invoice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = Db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(Db.Customers, "CustomerID", "FirstName", invoice.CustomerID);
            return View(invoice);
        }

        // POST: /Invoice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="InvoiceId,OrderDate,CustomerID,Totalprice")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(invoice).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(Db.Customers, "CustomerID", "FirstName", invoice.CustomerID);
            return View(invoice);
        }

        // GET: /Invoice/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = Db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: /Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = Db.Invoices.Find(id);
            Db.Invoices.Remove(invoice);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
