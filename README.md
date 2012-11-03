Unity utils
==

How to create an application:

	- Extend nController for your controllers.
	- Extend nApp and nStateFactory for the application.
	- Create a view class MyView that extends MonoBehaviour.
	- Create a new scene with a main camera and blank 'Main' object.
	- Attach the view class (MyView) to the blank object.
	- Create a 'launcher' scene that makes the first controller call.
	
App
--

The application is the core of this framework; the correct way to use
it is to have a public static instance.

View can then access controllers and make calls like this:

  var model = Hello.App.C<HomeController>(this).GetValue("blah").Model.As<MyViewModel>();
  ...

or perform update actions that do no have any response exception success:

  if(Hello.App.C<HomeController>(this).IsValid(99).Success) {
    ...
  }

or navigate to new locations using:

	Hello.App.C<GameController>(this).Loading().Activate();
	
This does tend to be quite verbose, so a good view should fetch the controllers
it needs to use at startup and keep references to them.

Notice that there is no way to pass data directly to a new view; this
is deliberate because some implementations of the utils class (Android noteably) 
cannot support this functionality.

Use the application state inside the controller to achieve this sort of 
functionality.

In HomeController:

  nView EditItem(int id) {
    _stateFactory.Get().As<AppState>().EditTarget = id;
    return View(ViewIds.EDIT_VIEW);
  }
  
In the EditController:

  nView GetActiveItem() {
    var id = _stateFactory.Get().As<AppState>().EditTarget;
    var item = _myRepo.Get(id);
    var model = new EditViewModel(item);
    return View(model);
  }
  
This sort of stateful information passing has a bunch of downsides, but it is
portable, which is the goal. If you don't want to use this mechanism, modify
your application object ot provide some custom object-caching solution that
can be called from the view when it starts.

Views
--

Remember not to attach the view behaviour to the camera on the scene for a 
view; that *will* break things if you use a customized camera.

The id passed from a controller to launch a view is directly passed to the
scene loader; make sure your scenes are named appropriately. 