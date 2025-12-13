import 'package:dio/dio.dart';
import 'package:kanjiro_app/Models/card_info_model.dart';
import 'package:kanjiro_app/Models/user_model.dart';
import 'package:kanjiro_app/Utils/Exceptions/kanjiro_api_exception.dart';

class ApiService {
  static final apiUrl = 'http://10.0.2.2:5288';
  static Future<UserModel> userLogin(String userName, String password) async {
    try {
      final dio = Dio();

      final response = await dio.post(
        '$apiUrl/User/Login',
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
      if (e.response != null) {
        throw KanjiroApiException(message: e.response!.data['message']);
      }

      throw Exception('Erro inesperado: ${e.message}');
    } catch (e) {
      throw Exception(e);
    }
  }

  static Future<UserModel> synchronizeChanges(UserModel user) async {
    try {
      final dio = Dio();

      final response = await dio.put(
        '$apiUrl/User/Synchronize',
        data: user.toJson(),
      );

      var json = response.data['returnData'];

      return UserModel.fromJson(json);
    } on DioException catch (e) {
      if (e.response != null) {
        throw KanjiroApiException(message: e.response!.data['message']);
      }

      throw Exception('Erro inesperado: ${e.message}');
    } catch (e) {
      throw Exception(e.toString());
    }
  }

  static Future<List<CardInfoModel>> searchKanjiByText(String text) async {
    try {
      final dio = Dio();

      final response = await dio.get(
        '$apiUrl/CardInfo',
        queryParameters: {'text': text},
      );

      var json = response.data['returnData'];

      return (json as List)
          .map((item) => CardInfoModel.fromJson(item))
          .toList();
    } on DioException catch (e) {
      if (e.response != null) {
        throw KanjiroApiException(message: e.response!.data['message']);
      }

      throw Exception('Erro inesperado: ${e.message}');
    } catch (e) {
      throw Exception(e.toString());
    }
  }

  static Future<void> addKanjiToDeck(int cardInfoId, int deckId) async {
    try {
      final dio = Dio();

      await dio.post(
        '$apiUrl/Deck/Card/Info/$cardInfoId',
        options: Options(headers: {'deckId': deckId}),
      );
    } on DioException catch (e) {
      if (e.response != null) {
        throw KanjiroApiException(message: e.response!.data['message']);
      }
    } catch (e) {
      throw Exception('Erro inesperado: ${e.toString()}');
    }
  }
}
