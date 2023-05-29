require 'sinatra'

# Define the URL shortener application
class URLShortenerApp < Sinatra::Base
  # Data structure to store URL mappings
  URL_MAP = {}

  # Generate a unique short URL
  def generate_short_url
    charset = Array('A'..'Z') + Array('a'..'z') + Array('0'..'9')
    Array.new(6) { charset.sample }.join
  end

  get '/' do
    erb :index
  end

  post '/shorten' do
    long_url = params[:long_url]
    short_url = generate_short_url

    URL_MAP[short_url] = long_url

    "Short URL: #{request.base_url}/#{short_url}"
  end

  get '/:short_url' do |short_url|
    long_url = URL_MAP[short_url]

    if long_url
      redirect long_url
    else
      "Short URL not found"
    end
  end

  run! if app_file == $0
end
