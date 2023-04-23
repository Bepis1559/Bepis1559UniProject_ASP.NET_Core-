document.addEventListener('DOMContentLoaded', () => {
   
    
    const rightPartNav = document.getElementById('rightPartNav')
    const leftPartNav = document.getElementById('leftPartNav')
    const removeClassFromEntry = (className, entry) => {
        return entry.target.classList.remove(className, entry.isIntersecting)
    }
    const observer = new IntersectionObserver(entries => {
        entries.forEach(entry => {
          
            removeClassFromEntry('rightTranslated', entry)
            removeClassFromEntry('opacity-0', entry)
            removeClassFromEntry('upTraslated',entry)
            removeClassFromEntry('leftTraslated',entry)

        })
    }, {
        threshold: 1,
    })
    
    observer.observe(leftPartNav)
    observer.observe(rightPartNav)
    

})
