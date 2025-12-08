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
    } on DioException catch (e) {
      throw Exception(e.message);
    } catch (e) {
      throw Exception(e);
    }
  }

  static Future<UserModel> synchronizeChanges(UserModel user) async {
    try {
      final dio = Dio();

      final response = await dio.put(
        'http://10.0.2.2:5288/User/Synchronize',
        data: user.toJson(),
      );

      var json = response.data['returnData'];

      return UserModel.fromJson(json);
    } on DioException catch (e) {
      throw new Exception(e.message);
    } catch (e) {
      throw Exception(e);
    }
  }
}
