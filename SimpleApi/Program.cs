var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minimal API V1");
});


var numberList = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
var lowerCharacters = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "y", "z", "x" };
var upperCharacters = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "Y", "Z", "X" };
var specialCharacters = new List<string> { ".", ",", "!", "?" };
var allCharacters = new List<string> ();
foreach (string element in numberList) 
{ 
    allCharacters.Add (element);
}

foreach (string element in lowerCharacters)
{
    allCharacters.Add(element);
}

foreach (string element in upperCharacters)
{
    allCharacters.Add(element);
}

foreach (string element in specialCharacters)
{
    allCharacters.Add(element);
}

string generatePassword(
    int length,
    int numbers
    ) {
    Random random = new Random();
    string password = string.Empty;

    for (int i = 0; i < numbers; i++ ) {
        var selectedIndex = random.Next(0, numberList.Count);
        var selectedChar = numberList[selectedIndex];
        password += selectedChar;
    }

    for (int i = 0; i < length-numbers; i++) {
      var selectedIndex =  random.Next(0, allCharacters.Count);
      var selectedChar = allCharacters[selectedIndex];
        password += selectedChar;
    }

    return password;
};

app.MapGet("/v2/generate", (
    int length,
    int count,
    int numbers
    ) =>
{
    List<string> resultPassword = new List<string>();
    for (int i = 0; i < count; i++) {
       string password = generatePassword(length,numbers);
        resultPassword.Add(password);
    }
    return resultPassword;
});

app.Run();