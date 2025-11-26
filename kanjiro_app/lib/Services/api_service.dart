import 'package:dio/dio.dart';

class ApiService {
  static Future<dynamic> userLogin(String userName, String password) async {
    try {
      final dio = Dio();

      final response = await dio.post(
        'http://10.0.2.2:5288/User/Login',
        data: {
          "Username": userName,
          "Password": password,
        },
        options: Options(
          contentType: Headers.jsonContentType,
        ),
      );

      print("Status: ${response.statusCode}");
      print("Status: ${response.data}");

      return response;
    } catch (e) {
      throw Exception(e);
    }
  }
}
