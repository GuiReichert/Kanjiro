import 'package:dio/dio.dart';
import 'package:kanjiro_app/Models/user_model.dart';

class ApiService {
  static Future<UserModel> userLogin(String userName, String password) async {
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

      var json = response.data['returnData'];
      return UserModel.fromJson(json);
    } catch (e) {
      throw Exception(e);
    }
  }
}
