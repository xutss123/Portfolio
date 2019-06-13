@extends('master')

@section('content')
<div class="mx-auto container">
    <div class="flex justify-center items-center h-screen">
        <div style="max-width: 600px;" class="w-full">
            <div class="bg-grey-light px-2 py-2 rounded">
            <div class="text-center font-bold text-2xl tracking-wide py-2">Hi, {{ $user->name }}!</div>


                    <form method="POST" class="px-2 py-2" action="/password">
                        @csrf

                        <div>
                            <label for="name" class="tracking-wide">Name</label>

                            <div class="mb-2">
                                <input id="name" type="text" class="border rounded h-10 w-full outline-none px-2 border-grey" disabled value="{{ $user->name }}">
                            </div>
                        </div>

                        <div>
                            <label for="email" class="tracking-wide">{{ __('E-Mail Address') }}</label>

                            <div class="mb-2">
                                <input id="email" type="email" class="border rounded h-10 w-full outline-none px-2 border-grey" disabled value="{{ $user->email }}">
                            </div>
                        </div>

                        <div>
                                <label for="opassword" class="tracking-wide">Old password</label>

                                <div class="col-md-6">
                                    <input id="old_password" type="password" class="border rounded h-10 w-full outline-none px-2 {{ $errors->has('old_password') ? ' border-red' : 'border-grey' }}" name="old_password" required>

                                    @if ($errors->has('old_password'))
                                        <span class="text-red-dark" role="alert">
                                            <strong>{{ $errors->first('old_password') }}</strong>
                                        </span>
                                    @endif
                                </div>
                            </div>

                        <div>
                            <label for="new_password" class="tracking-wide">New password</label>

                            <div class="col-md-6">
                                <input id="new_password" type="password" class="border rounded h-10 w-full outline-none px-2 {{ $errors->has('new_password') ? ' border-red' : 'border-grey' }}" name="new_password" required>

                                @if ($errors->has('new_password'))
                                    <span class="text-red-dark" role="alert">
                                        <strong>{{ $errors->first('new_password') }}</strong>
                                    </span>
                                @endif
                            </div>
                        </div>

                        <div >
                            <label for="password-confirm" class="tracking-wide">Confirm new password</label>

                            <div class="col-md-6">
                                <input id="password-confirm" type="password" class="border rounded h-10 w-full outline-none px-2" name="password_confirmation" required>
                            </div>
                        </div>


                        <button type="submit" class="mt-2 rounded px-4 py-2 text-blue-darkest bg-blue-light uppercase font-bold tracking-wide">
                            Change password
                        </button>

                    </form>

            </div>
        </div>
    </div>
</div>
@endsection
