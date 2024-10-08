require "net/http"
require "uri"
require "json"

class Intervals
  BASE_URL = "https://intervals.icu/api/v1"

  def initialize
    @username = ENV["INTERVALS_API_USERNAME"]
    @api_key = ENV["INTERVALS_API_KEY"]
    @user_id = ENV["INTERVALS_USERNAME"]
  end

  def get_calendar
    url = URI("#{BASE_URL}/athlete/#{@user_id}/calendars")
    http = Net::HTTP.new(url.host, url.port)
    http.use_ssl = true

    # Create a request with Basic Authentication
    request = Net::HTTP::Get.new(url)
    request.basic_auth(@username, @api_key)

    response = http.request(request)

    if response.code == "200"
      # Return the response body or process it as needed
      json_response = JSON.parse(response.body)
      json_response["calendar"]
    else
      Rails.logger.error "Intervals.icu API error: #{response.code} #{response.message}"
      nil
    end
  rescue => e
    Rails.logger.error "Intervals.icu API request failed: #{e.message}"
    nil
  end
end
