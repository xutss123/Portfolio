<!doctype html>
<html lang="{{ str_replace('_', '-', app()->getLocale()) }}">
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link href="https://cdn.jsdelivr.net/npm/tailwindcss/dist/tailwind.min.css" rel="stylesheet">
        <title>WEB3</title>
    </head>
    <body class="bg-grey-lightest font-sans">
        <div class="flex justify-center py-2">
            @if(!Auth::check())
                <a href='/' class="px-2 py-2 bg-grey-light hover:bg-grey text-xl text-black no-underline uppercase rounded mx-2">Login</a>
                <a href='/register' class="px-2 py-2 bg-grey-light hover:bg-grey text-xl text-black no-underline uppercase rounded mx-2">Register</a>
            @else
                <a href='/dashboard' class="px-2 py-2 bg-grey-light hover:bg-grey text-xl text-black no-underline uppercase rounded mx-2">Home</a>
                <a href='/profile' class="px-2 py-2 bg-grey-light hover:bg-grey text-xl text-black no-underline uppercase rounded mx-2">Profile</a>
                <a href='/offer/create' class="px-2 py-2 bg-grey-light hover:bg-grey text-xl text-black no-underline uppercase rounded mx-2">Add house</a>
                <a href='/someData' class="px-2 py-2 bg-grey-light hover:bg-grey text-xl text-black no-underline uppercase rounded mx-2">Some data</a>
                <a href='/allData'  class="px-2 py-2 bg-grey-light hover:bg-grey text-xl text-black no-underline uppercase rounded mx-2">All data</a>
                <a href='/people'  class="px-2 py-2 bg-grey-light hover:bg-grey text-xl text-black no-underline uppercase rounded mx-2">People</a>
                <a href='/logout'  class="px-2 py-2 bg-grey-light hover:bg-grey text-xl text-black no-underline uppercase rounded mx-2">Logout</a>
            @endif
        </div>
     @yield('content')
    </body>
</html>
