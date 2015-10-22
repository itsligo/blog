---
layout: branch
title: Step 2
published: true
description: add database using EF
img: img/2.jpg
---

####Branch **Stage 2** (w/s 19-10-15)

Home page depicts a list of **Blogs** with some complementary data - e.g. number of posts presented in a CSS-enhanced layout. Clicking a **Blog** (either the row depicting the blog or via a button) leads to a **View** for each **Blog** revealing more details of the **Blog** such as a list of **Post**s for that **Blog**. 

<iframe src="https://media.heanet.ie/player/42b1cec3f2c2d9383246496c9b3386bd&st=0" name="42b1cec3f2c2d9383246496c9b3386bd" width="640" height="360" marginwidth="0" marginheight="0" scrolling="no" frameborder="0" webkitAllowFullScreen allowFullScreen></iframe>

Links going in the reverse direction should also be coded. Again Bootstrap is used to improve presentation of this data.
**Models** are improved to provide an **Author** class with some attributes such as Name & Address (city will suffice).

Concepts covered:

* Data Annotations - to decorate fields for inclusion in **Views** for (say) localisation
* Basic querying of POCO to populate **ViewModels**
* Bootstrap enhanced **Views**