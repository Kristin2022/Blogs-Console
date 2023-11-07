
using NLog;
using System.Linq;

string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");

while (true)
{
    System.Console.WriteLine("Enter your selection: ");
    System.Console.WriteLine("1) Display all blogs");
    System.Console.WriteLine("2) Add Blog");
    System.Console.WriteLine("3) Create Post");
    System.Console.WriteLine("4) Display Posts");
    System.Console.WriteLine("5) To quit");
    string resp = Console.ReadLine();

    try
    {
        if (resp == "1")
        {
            DisplayAllBlogs();
        }
        else if (resp == "2")
        {
            AddBlog();
        }
        else if (resp == "3")
        {
            CreatePost();
        }
        else if (resp == "4")
        {
            DisplayPosts();
        }
        else if (resp == "5")
        {
            break;
        }
    }
    catch (Exception ex)
    {
        logger.Error(ex.Message);
    }
}

void DisplayPosts()
{
    throw new NotImplementedException();
}

void AddBlog()
{
    Console.Write("Enter a name for a new Blog: ");
    var name = Console.ReadLine();

    var blog = new Blog { Name = name };

    var db = new BloggingContext();
    db.AddBlog(blog);
    logger.Info("Blog added - {name}", name);
}
void DisplayAllBlogs()
{
    var db = new BloggingContext();
    var query = db.Blogs.OrderBy(b => b.Name);
    // using(var context = new ContextBlog())

    Console.WriteLine($"Option \"1\" selected\n{query.Count()} Blogs returned");

    foreach (var item in query)
    {
        Console.WriteLine(item.Name);
    }
}

void CreatePost()
{
    Console.WriteLine($"Option 3 was selected");
    try
    {
        var db = new BloggingContext();
        var query = db.Blogs.OrderBy(b => b.BlogId);
        Console.WriteLine("Select the blog you would like to post to: ");
        foreach (var item in query)
        {
            Console.WriteLine($"{item.BlogId}. {item.Name}");
        }
        Post post = new Post();
        post.BlogId = Convert.ToInt32(Console.ReadLine()); 
        Console.WriteLine("Enter the Post Title"); 
        post.Title = Console.ReadLine();
        Console.WriteLine("Enter Post Content");
        post.Content = Console.ReadLine();
        db.AddPost(post);
        logger.Info("Post added - {title}", post.Title);
    }
    catch (Exception ex)
    {
        System.Console.WriteLine("Invalid blog id" + ex.Message);
    }
}

logger.Info("Program ended");


// using NLog;
// using System.Linq;
// // See https://aka.ms/new-console-template for more information
// string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// // create instance of Logger
// var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
// logger.Info("Program started");

// try
// {

//     // Create and save a new Blog
//     Console.Write("Enter a name for a new Blog: ");
//     var name = Console.ReadLine();

//     var blog = new Blog { Name = name };

//     var db = new BloggingContext();
//     db.AddBlog(blog);
//     logger.Info("Blog added - {name}", name);

//     // Display all Blogs from the database
//     var query = db.Blogs.OrderBy(b => b.Name);

//     Console.WriteLine("All blogs in the database:");
//     foreach (var item in query)
//     {
//         Console.WriteLine(item.Name);
//     }
// }
// catch (Exception ex)
// {
//     logger.Error(ex.Message);
// }

// logger.Info("Program ended");

// while(true)
// {
//     System.Console.WriteLine("Enter your selsection: ");
//     System.Console.WriteLine("1) Display all blogs");
//     System.Console.WriteLine("2) Add Blog");
//     System.Console.WriteLine("3) Create Post");
//     System.Console.WriteLine("4) Display Posts");
//     System.Console.WriteLine("5) To quit");
//     string resp = Console.ReadLine();
//     resp = Console.ReadLine();

//     if (resp == "1")
//     {
//         DisplayAllBlogs(); 
//     }
//     else if (resp == "2")
//     {
//         AddBlog();
//     }
//     else if (resp == "3")
//     {
//         CreatePost();
//     }
//     else if (resp == "4")
//     {
//         DisplayPosts();
//     }
//     else if (resp == "5")
//         break;
// }

// void DisplayPosts()
// {
//     throw new NotImplementedException();
// }

// void AddBlog()
// {
//     throw new NotImplementedException();
// }

// void DisplayAllBlogs()
// {
//     throw new NotImplementedException();
// }

// void CreatePost()
// {
//     throw new NotImplementedException();
// }

    // var db = new BloggingContext();
    //     var query = db.Blogs.OrderBy(b => b.BlogId);
    //     Console.WriteLine("Select the blog you would like to post to: ");
    //     foreach (var item in query)
    //     {
    //         Console.WriteLine($"1{item.BlogId}. {item.Name}");
    //         if (item.BlogId == 1)
    //         {
    //             Console.Write("Enter a name for a new Post: ");
    //             var title = Console.ReadLine();

    //             var Post = new Post { Title = title };

    //             var dbPost = new Post();
    //             db.AddPost();
    //             logger.Info("Title added - {title}", title);
    //         }
    //     }
    //     var BlogId = Console.ReadLine();
    //     var PostTitle = Console.ReadLine();