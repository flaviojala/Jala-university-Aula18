using Design.Pattern.Command.Api;
using Design.Pattern.Mediator;
using Design.Pattern.Mediator.ChatRoomExample;
using Design.Pattern.Mediator.ChatRoomExample.Commands;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddMediator(typeof(Program));
services.AddMemoryCache();

var provider = services.BuildServiceProvider();
var mediator = provider.GetRequiredService<IMediator>();

Console.WriteLine(mediator.Send(new CollegueA()));
Console.WriteLine(mediator.Send(new CollegueB()));
Console.WriteLine(mediator.Send(new CollegueC()));

var from = new Developer("Developer");
var to = new Tester("Tester");
var message = "This is the code that need to be tested";

mediator.Send(new RegisterTeamMembersCommand() { TeamMember = from });
mediator.Send(new RegisterTeamMembersCommand() { TeamMember = to });
mediator.Send(new MessageCommand() { From = from, To = to, Message = message });


// var receivers = new Dictionary<Type, Type>()
// {
//     {typeof(CollegueA), typeof(CollegueHandler)},
//     {typeof(CollegueB), typeof(CollegueHandler)},
//     {typeof(CollegueC), typeof(CollegueHandler)}
//     
// };

// var collegueHandler = new CollegueHandler();
//
// var collegueList = new List<(Type, object)>()
// {
//     (typeof(CollegueHandler), collegueHandler)
// };
//
// object GetRequiredService(Type type)
// {
//     return collegueList.FirstOrDefault(x => x.Item1 == type).Item2;
// }
//
// var getRequiredServiceFunc = 
//     new Func<Type, object>(type => collegueList.FirstOrDefault(x => x.Item1 == type).Item2);
//
// var mediator = new Mediator(GetRequiredService ,receivers);

