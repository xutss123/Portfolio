@extends('master')

@section('content')
<div class="mx-auto container">
    <div class="flex justify-center items-center h-screen">
        <div style="max-width: 600px;" class="w-full">
            <div class="bg-grey-light px-2 py-2 rounded">
                <div class="text-center font-bold text-2xl tracking-wide uppercase py-2">{{ __('Register') }}</div>


                <form method="POST" action="{{ route('register') }}">
                    @csrf

                    <div>
                        <label for="name" class="tracking-wide">{{ __('Name') }}</label>

                        <div class="col-md-6">
                            <input id="name" type="text" class="border rounded h-10 w-full outline-none px-2 {{ $errors->has('name') ? ' border-red' : 'border-grey'}}" name="name" value="{{ old('name') }}" required autofocus>

                            @if ($errors->has('name'))
                                <span class="text-red-dark" role="alert">
                                    <strong>{{ $errors->first('name') }}</strong>
                                </span>
                            @endif
                        </div>
                    </div>

                    <div >
                        <label for="email" class="tracking-wide">{{ __('E-Mail Address') }}</label>

                        <div class="col-md-6">
                            <input id="email" type="email" class="border rounded h-10 w-full outline-none px-2 {{ $errors->has('email') ? ' border-red' : 'border-grey'}}" name="email" value="{{ old('email') }}" required>

                            @if ($errors->has('email'))
                                <span class="text-red-dark" role="alert">
                                    <strong>{{ $errors->first('email') }}</strong>
                                </span>
                            @endif
                        </div>
                    </div>

                    <div >
                        <label for="password" class="tracking-wide">{{ __('Password') }}</label>

                        <div class="col-md-6">
                            <input id="password" type="password" class="border rounded h-10 w-full outline-none px-2 {{ $errors->has('password') ? ' border-red' : 'border-grey'}}" name="password" required>

                            @if ($errors->has('password'))
                                <span class="text-red-dark" role="alert">
                                    <strong>{{ $errors->first('password') }}</strong>
                                </span>
                            @endif
                        </div>
                    </div>

                    <div >
                        <label for="password-confirm" class="tracking-wide">{{ __('Confirm Password') }}</label>

                        <div class="col-md-6">
                            <input id="password-confirm" type="password" class="border rounded h-10 w-full outline-none px-2" name="password_confirmation" required>
                        </div>
                    </div>

                    <button type="submit" class="mt-2 rounded px-4 py-2 text-blue-darkest bg-blue-light uppercase font-bold tracking-wide">
                        {{ __('Register') }}
                    </button>

                </form>
            </div>
        </div>
    </div>
</div>
@endsection
