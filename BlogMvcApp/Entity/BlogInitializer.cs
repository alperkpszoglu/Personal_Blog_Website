using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BlogMvcApp.Entity
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {

            var categories = new List<Category>
            {               
                new Category(){CategoryName="C#"},
                new Category(){CategoryName="Asp.net MVC"},
                new Category(){CategoryName="Asp.net Web Api"},
                new Category(){CategoryName="Asp.net Core"}
            };

            foreach (var item in categories)
            {
                context.Categories.Add(item);
            }
            context.SaveChanges();
            var blogs = new List<Blog>
            {
                new Blog(){Heading="C# Model Binding Nasıl Yapılır?",Description="C#'da model binding işlemi hakkında",AddedTime=DateTime.Now.AddDays(-10),Homepage=true,Approve=true,Content="C#'da model binding işlemi hakkındaC#'da model binding işlemi hakkındaC#'da model binding işlemi hakkındaC#'da model binding işlemi hakkında",Image="1.jpg",CategoryId=1},
                new Blog(){Heading="C# Generic Yapılar",Description="C#'da Generic yapılar hakkında",AddedTime=DateTime.Now.AddDays(-15),Homepage=true,Approve=true,Content="C#'da Generic yapılar hakkındaC#'da Generic yapılar hakkındaC#'da Generic yapılar hakkındaC#'da Generic yapılar hakkındaC#'da Generic yapılar hakkında",Image="1.jpg",CategoryId=1},
                new Blog(){Heading="Asp.net MVC router işlemleri",Description="Asp.net Mvc home/index",AddedTime=DateTime.Now.AddDays(-30),Homepage=false,Approve=true,Content="Asp.net Mvc home/indexAsp.net Mvc home/indexAsp.net Mvc home/indexAsp.net Mvc home/indexAsp.net Mvc home/indexAsp.net Mvc home/index",Image="2.jpg",CategoryId=2},
                new Blog(){Heading="Asp.net Core'a geçiş",Description="asp.net core çarpraz platform",AddedTime=DateTime.Now.AddDays(-20),Homepage=true,Approve=true,Content="asp.net core çarpraz platformasp.net core çarpraz platformasp.net core çarpraz platformasp.net core çarpraz platformasp.net core çarpraz platformasp.net core çarpraz platform",Image="1.jpg",CategoryId=4},
                new Blog(){Heading="C# Model Binding Nasıl Yapılır?",Description="C#'da model binding işlemi hakkında",AddedTime=DateTime.Now.AddDays(-12),Homepage=false,Approve=false,Content="C#'da model binding işlemi hakkındaC#'da model binding işlemi hakkındaC#'da model binding işlemi hakkındaC#'da model binding işlemi hakkında",Image="1.jpg",CategoryId=3},
                new Blog(){Heading="C# Model Binding Nasıl Yapılır?",Description="C#'da model binding işlemi hakkında",AddedTime=DateTime.Now.AddDays(-16),Homepage=true,Approve=false,Content="C#'da model binding işlemi hakkındaC#'da model binding işlemi hakkındaC#'da model binding işlemi hakkındaC#'da model binding işlemi hakkında",Image="1.jpg",CategoryId=2},
                new Blog(){Heading="C# Model Binding Nasıl Yapılır?",Description="C#'da model binding işlemi hakkında",AddedTime=DateTime.Now.AddDays(-23),Homepage=true,Approve=true,Content="C#'da model binding işlemi hakkındaC#'da model binding işlemi hakkındaC#'da model binding işlemi hakkındaC#'da model binding işlemi hakkında",Image="2.jpg",CategoryId=1},
                new Blog(){Heading="C#'da tür dönüşümü?",Description="C#'da cast işlemi nasıl yapılır",AddedTime=DateTime.Now.AddDays(-50),Homepage=true,Approve=true,Content="C#'da tür dönüşümü nasıl yapılır tür dönüşümü nasıl yapılırtür dönüşümü nasıl yapılırtür dönüşümü nasıl yapılır",Image="1.jpg",CategoryId=1},
                new Blog(){Heading="C# Model Binding Nasıl Yapılır?",Description="C#'da model binding işlemi hakkında",AddedTime=DateTime.Now.AddDays(-45),Homepage=true,Approve=true,Content="C#'da model binding işlemi hakkındaC#'da model binding işlemi hakkındaC#'da model binding işlemi hakkındaC#'da model binding işlemi hakkında",Image="2.jpg",CategoryId=1},
                new Blog(){Heading="C# Model Binding Nasıl Yapılır?",Description="C#'da model binding işlemi hakkında",AddedTime=DateTime.Now.AddDays(-5),Homepage=true,Approve=false,Content="C#'da model binding işlemi hakkındaC#'da model binding işlemi hakkındaC#'da model binding işlemi hakkındaC#'da model binding işlemi hakkında",Image="1.jpg",CategoryId=4},
                new Blog(){Heading="C# Model Binding Nasıl Yapılır?",Description="C#'da model binding işlemi hakkında",AddedTime=DateTime.Now.AddDays(-6),Homepage=false,Approve=true,Content="C#'da model binding işlemi hakkındaC#'da model binding işlemi hakkındaC#'da model binding işlemi hakkındaC#'da model binding işlemi hakkında",Image="2.jpg",CategoryId=4},
                new Blog(){Heading="C# Model Binding Nasıl Yapılır?",Description="C#'da model binding işlemi hakkında",AddedTime=DateTime.Now.AddDays(-21),Homepage=true,Approve=true,Content="C#'da model binding işlemi hakkındaC#'da model binding işlemi hakkındaC#'da model binding işlemi hakkındaC#'da model binding işlemi hakkında",Image="1.jpg",CategoryId=3},
                new Blog(){Heading="C# Model Binding Nasıl Yapılır?",Description="C#'da model binding işlemi hakkında",AddedTime=DateTime.Now.AddDays(-24),Homepage=true,Approve=false,Content="C#'da model binding işlemi hakkındaC#'da model binding işlemi hakkındaC#'da model binding işlemi hakkındaC#'da model binding işlemi hakkında",Image="2.jpg",CategoryId=3},
                new Blog(){Heading="C# Model Binding Nasıl Yapılır?",Description="C#'da model binding işlemi hakkında",AddedTime=DateTime.Now.AddDays(-19),Homepage=true,Approve=true,Content="C#'da model binding işlemi hakkındaC#'da model binding işlemi hakkındaC#'da model binding işlemi hakkındaC#'da model binding işlemi hakkında",Image="1.jpg",CategoryId=4},
            };

            foreach (var item in blogs)
            {
                context.Blogs.Add(item);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}