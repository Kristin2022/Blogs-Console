
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
     var db = new BloggingContext();
    var query = db.Posts.OrderBy(b => b.PostId);

     Console.WriteLine($"Option \"4\" selected\n{query.Count()} Posts returned");

    foreach (var item in query)
    {
        Console.WriteLine(item.PostId + item.Title + item.Content);
    }
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
        logger.Info("Post added - /n{title}", post.Title);
    }
    catch (Exception ex)
    {
        System.Console.WriteLine("Invalid blog id" + ex.Message);
    }
}

logger.Info("Program ended");
