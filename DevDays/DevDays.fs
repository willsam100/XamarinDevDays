module DevDaysM
open System
open Xamarin.Forms

let tryParse x =
  let result = Int32.TryParse x
  match result with
    | true, v    -> Some v
    | false, _   -> None

let square x = x * x

type MainPage() as this = 
    inherit ContentPage()

    let stack = StackLayout(VerticalOptions = LayoutOptions.FillAndExpand)

    let first = Entry()
    let button = Button(Text = "Add")
    let output = Label(XAlign = TextAlignment.Center, Text = "")

    let buttonHandler x = 
      let result = match tryParse first.Text  with 
                    | Some y -> (square y).ToString()
                    | None   -> "enter a number"
      output.Text <- result

    do
        button.Clicked.AddHandler (new EventHandler(fun x -> buttonHandler))
        stack.Children.Add(first)
        stack.Children.Add(button)
        stack.Children.Add(output)
        this.Content <- stack

type App() =
    inherit Application(MainPage = MainPage())
