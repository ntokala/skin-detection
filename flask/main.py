from flask import Flask, jsonify, request, redirect
import skinny

app = Flask(__name__)

@app.route("/classifier", methods=["POST"])
def classifier():
    file = request.files['image']
    diffs = skinny.classify_lesion(file.stream)

    response = jsonify(diffs)
    response.status_code = 200
    print(response)
    return response

    # return jsonify({'msg': 'success', 'class': ans})

if __name__ == "__main__":
    app.run(debug=True)