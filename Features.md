Features to implement
=====================

## With/without result
This is done and works. One button blocks UI while the other does not.

## With/without await

## update UI from background thread
This is done, but oddly it work even if I try to update from the background thread. 
I think this might be Xamarin.Forms doing something in their implementation of either SetProperty<> or INotifyPropertyChanged that dispatches to the UI thread.
I think the way to test this for realz is by triggering an event. Getting the object that sends the event. Cast it and then set a value from background thread. 
This is also what is done in the video: 19:15 https://channel9.msdn.com/Shows/XamarinShow/Best-Practices-Async--Await--The-Xamarin-Show

Events

Events for updating across other areas. 
Craeate component that triggers events like Iv'e seen Nicolas do. 

update UI via beginInvoke build into SetProperty<>
update UI via beginInvoke on each property

configure await false
configure await true

yield return 

Use generic classes

Use generics in methods

Open settings

Cache / uncache image

Linq 

Temporal coupling with i it token/initted sdk

Nullable

Try catch

Rethrow exception 

Ref/out 


M's poorer version that gives more complexity, less readability, he's comment is "you just gotta know the API".
Show how to build with explicit design so as to ease the maintenence burden 
Link to articles from web course.
Taken from PR update of ElementTransistion

