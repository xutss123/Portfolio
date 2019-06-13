<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class HomePageController extends Controller
{
    public function __construct()
    {
        $this->middleware('auth');
    }

    public function index(){
        return view('index');
    }

    public function some(){
        return view('someData', [ 'data' => \App\House::select('address', 'description')->get() ]);
    }

    public function profile(){
        return view('profile', [ 'user' => \Auth::user() ]);
    }

    public function password(Request $request){
        $user = \Auth::user();

        $rules = array(
            'new_password'          => 'min:5|required|string',
            'old_password'          => 'required',
            'password_confirmation' => 'required'
        );

        if($request->get('new_password') != $request->get('password_confirmation')){
            return \Redirect::back()->withErrors([
                'new_password' => 'Please repeat your new password'
            ]);
        }

        $validator = \Validator::make($data = $request->all(), $rules);

        if ($validator->fails())
        {
            return \Redirect::back()->withErrors($validator);
        }

        if(\Hash::check($request->get('old_password'), $user->password)){
            $user->update([
                'password' =>  \Hash::make($request->get('new_password'))
            ]);
            return \Redirect::back();
        } else {
            return \Redirect::back()->withErrors([
                'old_password' => 'Your old password is incorrect'
            ]);
        }
    }

    public function all(){
        return view('allData', [ 'data' => \App\House::all() ]);
    }
}
