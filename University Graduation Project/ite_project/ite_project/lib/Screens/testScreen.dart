import 'package:flutter/material.dart';
import 'package:gsheets/gsheets.dart';
import 'package:ite_project/constants.dart';
import 'package:ite_project/models/reportForm.dart';
import 'package:ite_project/models/sessionStudents.dart';
import 'package:ite_project/models/students.dart';

class TestScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        color: Colors.white,
        child: Center(
          child: TextButton(
            child: Text("Press Me"),
            onPressed: () async {
              await main();
              print('done');
            },
          ),
        ),
      ),
    );
  }

  Future<void> main() async {
    // init GSheets
    final gsheets = GSheets(credentials);
    // fetch spreadsheet by its id
    final ss = await gsheets.spreadsheet(spreadsheetId);
    // get worksheet by its title
    var sheet = ss.worksheetByTitle('example');
    // create worksheet if it does not exist yet
    sheet ??= await ss.addWorksheet('example');
    await sheet.values.insertRow(1, firstRow);
  }
}
