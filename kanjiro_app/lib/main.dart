import 'package:flutter/material.dart';
import 'package:kanjiro_app/Views/home_page.dart';
import 'package:kanjiro_app/Views/login_page.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(home: const HomePage());
  }
}
