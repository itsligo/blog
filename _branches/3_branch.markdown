---
layout: branch
title: Step 3
published: true
description: entity framework
img: img/3.jpg
---

####Branch **Stage 3** (w/s 2-11-15)

![stage3]({{site.baseurl}}/img/stage3.png){: .right .boxed}

The database is now persisting all data. We can over-ride the default (invisible) connection string in web.config by specifying out own. Use Server Explorer to get the *Data Source* for the server. Or use [www.connectionstrings.com](http://www.connectionstrings.com) to fashion the connstring for you. Or here's one to use:

    <add name="BlogDb" connectionString="Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\blogdb.mdf;Integrated Security=True; MultipleActiveResultSets=True;" providerName="System.Data.SqlClient" />

Note with the above connstring, the database will be created in the **AppData** folder - right-click and open in File Explorer to witness this. You could add the two database files to the project if you prefer to see them in Solution Explorer.

![stage3]({{site.baseurl}}/img/stage3a.png){: .right .boxed}

Next we seed the database properly rather than through the ctor of the **HomeController** - that's why we saw duplicated data on screen in previous branches - the ctor was being called on each page refresh. Use a dedicated `DropCreateDatabaseAlways<OurDbContext> Class` and over-ride its **Seed** method to provide seed data. Ensure you add `System.Data.Entity.Database.SetInitializer(new  DataContextInitializer());` to prompt EF (Entity Framework) to use your initialiser.

Next, we fix up the **More** link from the home page so that it provides the **Id** of each **Blog**. Then we use **Find()** to look up the associated **Blog** in the database.

![stage3]({{site.baseurl}}/img/stage3b.png){: .right .boxed}

Styling now incorporates more Boostrap classes. I've also added some snippets of Bootstrap from [Bootsnipp](www.bootsnipp.com) to present the blog posts in boxes on the Details page. The small amount of CSS was accommodated in the `site.css` file. The javascript to drive the interactive feature is inserted in a Razor section and injected by the `_layout.cshtml` master page.

Concepts covered:

* Database initialisation & seeding
* Entity Framework (EF) entity lookup i.e. **Find()**
* Perform some entity manipulation via **Razor**
* Improved styling of buttons and other screen artifacts
* Improved error handling i.e. where there is no data
