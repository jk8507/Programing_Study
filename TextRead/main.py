import boto3

# Document
documentName = "text.jpg"
text = []

# Read document content
with open(documentName, 'rb') as document:
    imageBytes = bytearray(document.read())

# Amazon Textract client
textract = boto3.client('textract')

# Call Amazon Textract
response = textract.detect_document_text(Document={'Bytes': imageBytes})

for item in response["Blocks"]:
    if item["BlockType"] == "LINE":
     text.append(item["Text"])

polly_client = boto3.Session(
                aws_access_key_id='',
                aws_secret_access_key='',
                region_name='us-west-2').client('polly')

for i in range(0, len(text)):
    response[i] = polly_client.synthesize_speech(VoiceId='Joanna',
                OutputFormat='mp3',
                Text = text[i])

file = open('speech.mp3', 'wb')
for i in range(0, len(text)):
    file.write(response[i]['AudioStream'].read())

file.close()
