import 'package:flutter/material.dart';
import 'package:injector/injector.dart';
import 'package:kanjiro_app/ViewModels/user_viewmodel.dart';
import 'package:kanjiro_app/Views/home_page.dart';
import 'package:kanjiro_app/Widgets/background_escuro_widget.dart';

class LoginPage extends StatelessWidget {
  LoginPage({super.key});

  final userViewModel = Injector.appInstance.get<UserViewmodel>();
  final txtUserController = TextEditingController();
  final txtPasswordController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: KanjiroBackgroundEscuro(
        widgetFilho: Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              SizedBox(height: 150),
              Text(
                'Login',
                style: TextStyle(color: Colors.white, fontSize: 50),
              ),
              loginBox(context),
              Spacer(),
            ],
          ),
        ),
      ),
    );
  }

  Container loginBox(BuildContext ctx) {
    return Container(
      decoration: BoxDecoration(
        color: const Color.fromARGB(157, 146, 170, 221),
        borderRadius: BorderRadius.circular(8),
        boxShadow: [
          BoxShadow(color: Colors.black26, blurRadius: 8, offset: Offset(0, 4)),
        ],
      ),
      width: 300,
      height: 500,
      child: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            Padding(
              padding: EdgeInsetsDirectional.only(start: 10),
              child: Text(
                'Username',
                textAlign: TextAlign.center,
                style: TextStyle(
                  color: Colors.white,
                  fontSize: 18,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
            SizedBox(height: 10),
            SizedBox(
              height: 65,
              child: TextField(
                controller: txtUserController,
                decoration: InputDecoration(
                  filled: true,
                  fillColor: Colors.white,
                  hintText: 'Login',
                  contentPadding: EdgeInsets.only(left: 10),
                  border: OutlineInputBorder(
                    borderRadius: BorderRadius.circular(5),
                  ),
                ),
              ),
            ),
            SizedBox(height: 10),
            Padding(
              padding: EdgeInsetsDirectional.only(start: 10),
              child: Text(
                'Password',
                textAlign: TextAlign.center,
                style: TextStyle(
                  color: Colors.white,
                  fontSize: 18,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
            SizedBox(height: 10),
            SizedBox(
              height: 65,
              child: TextField(
                controller: txtPasswordController,
                obscureText: true,
                decoration: InputDecoration(
                  filled: true,
                  fillColor: Colors.white,
                  hintText: 'Password',
                  contentPadding: EdgeInsets.only(left: 10),
                  border: OutlineInputBorder(
                    borderRadius: BorderRadius.circular(5),
                  ),
                ),
              ),
            ),
            SizedBox(height: 30),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceAround,
              children: [
                ElevatedButton(onPressed: () {}, child: Text('Create Account')),
                Spacer(),
                ElevatedButton(
                  onPressed: () {
                    _pressLogin(ctx);
                  },
                  child: Text('Login'),
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }

  Future<void> _pressLogin(BuildContext ctx) async {
    await userViewModel.loadUser(
      txtUserController.text,
      txtPasswordController.text,
    );

    Navigator.pushReplacement(
      ctx,
      MaterialPageRoute(builder: (ctx) => HomePage()),
    );
  }
}
