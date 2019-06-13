<?php

namespace App\Http\Controllers;

use \App\User;
use Illuminate\Http\Request;

class APIController extends Controller
{
    function index(){
        return response()->json([
            'users' => User::all()
        ], 200);
    }

    function get(Request $request, User $user){
        return response()->json([
            'user' => $user
        ], 200);
    }

    function store(Request $request){
        $rules = array(
            'name' => ['required', 'string', 'max:255'],
            'email' => ['required', 'string', 'email', 'max:255', 'unique:users'],
            'password' => ['required', 'string', 'min:6', 'confirmed'],
        );

        $validator = \Validator::make($data = $request->all(), $rules);

        if ($validator->fails())
        {
            return response()->json([
                'errors' => $validator->errors()->all()
            ], 500);
        }

       $user = User::create($data);
       return response()->json([
           'user' => $user
       ], 200);
    }

    function update(Request $request, User $user){
        $rules = array(
            'name' => ['string', 'max:255'],
            'email' => ['string', 'email', 'max:255', 'unique:users']
        );

        $validator = \Validator::make($data = $request->all(), $rules);

        if ($validator->fails())
        {
            return response()->json([
                'errors' => $validator->errors()->all()
            ], 500);
        }

        $user->update($data);
        return response()->json([
            'user' => User::find($user->id)
        ], 200);
        
    }

    function destroy(Request $request, User $user){
        $user->delete();

        return response()->json([
            'message' => 'User deleted'
        ], 200);
    }
}
