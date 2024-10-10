class PagesController < ApplicationController
  def index
  end

  def about
    
  end

  def hardware
  end

  def training
    @calendar_data = Intervals.new.get_calendar
    Rails.logger.debug "Calendar data: #{@calendar_data.inspect}"
  end

  def contact
  end
end
