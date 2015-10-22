---
layout: branch
title: Step 3
published: true
description: entity framework
img: img/3.jpg
---

####Branch **Stage 3** (w/s 26-10-15)

![stage3]({{site.baseurl}}/img/stage3.png){: .right .boxed}


The database is now persisting all data. We can over-ride the default (invisible) connection string in web.config by specifying out own. Use Server Explorer to get the *Data Source* for the server. Or use [www.connectionstrings.com](http://www.connectionstrings.com) to fashion the connstring for you.

Next we seed the database properly rather than through the ctor of the **HomeController** - that's why we saw duplicated data on screen in previous branches - the ctor was being called on each page refresh. Use a dedicated `DropCreateDatabaseAlways&lt;OurDbContext&gt; Class` and over-ride its **Seed** method to provide seed data. Ensure you add `System.Data.Entity.Database.SetInitializer(new  DataContextInitializer());` to prompt EF (Entity Framework) to use your initialiser.

Next, we fix up the **More** link from the home page so that it provides the **Id** of each **Blog**. Then we use **Find()** to look up the associated **Blog** in the database.

Concepts covered:

* Database initialisation & seeding
* Entity Framework (EF) entity lookup i.e. **Find()**
* Perform some entity manipulation via **Razor**
* Improved styling of buttons and other screen artifacts