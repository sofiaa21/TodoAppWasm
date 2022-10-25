
namespace Shared.Models;

public class Todo
{
    public int Id { get; set; }
    public User Owner { get; }
    public string Title { get; }
    public bool IsCompleted { get; set; }

    public Todo(User owner, string title)
    {
        Owner = owner;
        Title = title;
    }
    
    /*
 Given that it is a Todo app,
 the Todo is a key model, and we let the Todo
 keep track of its assignee,
 instead of the other way around.
 */
}