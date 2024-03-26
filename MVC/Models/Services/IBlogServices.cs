using MVC.Models.Entities;

public interface IBlogServices
{
    IEnumerable<Post> GetLatestPosts(int max);
    IEnumerable<Post> GetPostsByDate(int year, int month);
    Post GetPost(string slug);
}
