provider "aws" {
  region = "us-east-1"
}

# IAM Role for Lambda
resource "aws_iam_role" "lambda_exec_role" {
  name = "lumilite_lambda_role"
  assume_role_policy = jsonencode({
    Version = "2012-10-17"
    Statement = [{
      Action = "sts:AssumeRole"
      Effect = "Allow"
      Principal = {
        Service = "lambda.amazonaws.com"
      }
    }]
  })
}

# Mock AWS Lambda Function (AI Worker)
resource "aws_lambda_function" "ai_worker" {
  function_name = "LumiLiteAIWorker"
  role          = aws_iam_role.lambda_exec_role.arn
  handler       = "main.handler"
  runtime       = "python3.10"
  
  # Note: A dummy placeholder since we aren't executing this
  filename      = "dummy_payload.zip" 
}

# Mock API Gateway
resource "aws_api_gateway_rest_api" "lumilite_api" {
  name        = "LumiLiteGateway"
  description = "API Gateway for LumiLite Assessment Service"
}
