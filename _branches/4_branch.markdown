---
layout: branch
title: Stage 4
published: true
description: tbc
img: img/4.jpg
---
####Branch **Stage 4** (w/s 16-11-15)

![stage4]({{site.baseurl}}/img/stage4.gif){: .right .boxed}

At this point we have a database populated (on each run) with data. We can view the details of each **Blog** and see the **Posts** represented in a novel way. There is also navigation between the home page (with list of **Blogs**) and the *Details* page.

Next we extend the **CRUD** operations by adding pages for *Create* and *Delete*. We also improve the styling in a few places e.g. showing number of **Posts** on the home page.

Scaffolding can be used to generate much of the code - this creates action methods in the controller and corresponding views in the appropriate Views folder. You will need to re-style these boilerplate coded templates to suit your own needs.

###Referential Integrity
You'll notice that the *Delete* code is more complicated than *Create*. This is due to the default referential integrity constraints imposed for 1-to-many relations such as between a **Blog** and its **Posts** - a common occurence. There are several ways to handle this but the simplest for now is before we delete a **Blog**, we delete all related **Post**s. In this way, the the **Blog** can be relieved of the referential integrity constraint.

###Get and Post
You'll notice therer are seemingly two methods for both *Create* and *Delete*. Remember that the *Create* View must first be presented to the user so that values can be input. This is invoked by calling the *Create* action method using the HTTP verb GET. When the form is completed and submitted, the version of the Create method marked as HTTP POST is called and passed the data gathered from the form completed by the user. Only then can the data be persisted to the database.
The *Delete* handling is very similar save for the issues around referential integrity mentioned above.